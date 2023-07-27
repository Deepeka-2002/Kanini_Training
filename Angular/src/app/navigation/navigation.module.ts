import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//import { NavComponent} from '../nav/nav.component';
import { DropdownComponent } from '../dropdown/dropdown.component'; 

@NgModule({
  declarations: [
    DropdownComponent
  ],
  imports: [
    CommonModule,
    DropdownComponent
  ]
})
export class NavigationModule { }
