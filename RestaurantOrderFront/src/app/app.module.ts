import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';

//Added imports
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { OrderService } from './order.service';
import { HttpClientModule } from '@angular/common/http';

const appRoutes: Routes = [
  { path: '', component: MainComponent }
 
];

@NgModule({
  declarations: [
    AppComponent,
    MainComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    FormsModule,
    BrowserModule,
    HttpClientModule
  ],
  providers: [OrderService],
  bootstrap: [
    AppComponent, 
    MainComponent
  ]
})
export class AppModule { }
