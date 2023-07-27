import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule,ReactiveFormsModule} from '@angular/forms'
import {HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { AllstudentsComponent } from './allstudents/allstudents.component';
import { StudentbyidComponent } from './studentbyid/studentbyid.component';
import { AddstudentComponent } from './addstudent/addstudent.component';
import { UpdatestudentComponent } from './updatestudent/updatestudent.component';
import { DeletestudentComponent } from './deletestudent/deletestudent.component';

@NgModule({
  declarations: [
    AppComponent,
    AllstudentsComponent,
    StudentbyidComponent,
    AddstudentComponent,
    UpdatestudentComponent,
    DeletestudentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
