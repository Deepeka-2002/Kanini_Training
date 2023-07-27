import { Routes } from "@angular/router";
import { BugsComponent } from "./bugs/bugs.component";
import { ContactComponent } from "./contact/contact.component";
import { HomeComponent } from "./home/home.component";
import { ProductComponent } from "./product/product.component";

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'contact', component: ContactComponent },
    { path: 'product', component: ProductComponent },
    { path: '', redirectTo: 'home', pathMatch: 'full' },  //default route 
    { path: '**', component: BugsComponent }   //wild card route
  ];