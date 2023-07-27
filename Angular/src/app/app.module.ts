import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ContactComponent } from './contact/contact.component';
import { ProductComponent } from './product/product.component';
import { BugsComponent } from './bugs/bugs.component';
import { appRoutes } from './app.routes';
import { ProductService } from './product/product.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ContactComponent,
    ProductComponent,
    BugsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    // path location strategy 
     RouterModule.forRoot(appRoutes)
    // Hashlocationstrategy 
    //RouterModule.forRoot(appRoutes, { useHash: true })
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
