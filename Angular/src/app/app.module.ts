import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
//import { DropdownComponent }from 'src/app/dropdown/dropdown.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
   
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent,NavComponent]
})
export class AppModule { }
