import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

const endpoint = 'https://localhost:5001/api/order';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class OrderService {

  constructor(private http: HttpClient) { }

  private extractData(res: Response) {
    let body = res;
    return body || { };
  }

  getOrders(): Observable<any> {
    return this.http.get(endpoint).pipe(
      map(this.extractData));
  }

  addOrder (order): Observable<any> {
    console.log(order);
    return this.http.post<any>(endpoint, JSON.stringify(order), httpOptions).pipe(
      tap((product) => console.log(`added order ${order.originalOrder}`)),
      catchError(this.handleError<any>('addOrder'))
    );
  }
  
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error); 
      console.log(`${operation} failed: ${error.message}`);
  
      return of(result as T);
    };
  }
}
