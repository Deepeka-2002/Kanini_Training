import { Component } from '@angular/core';

@Component({
  selector: 'app-pipes',
  templateUrl: './pipes.component.html',
  styleUrls: ['./pipes.component.css']
})
export class PipesComponent {
 dateobj = new Date();
 numbersarray =[12,67,98,9,4,78];
 namesarray = ['sss','ueu','iwej','jjs'];
 str = "Hello world!"

 course = {
  id : 'c1',
  cname :{
    topic :'Angular',
    subtopic : 'pipes'
  }
 };

 emoji ={
  'happy' : ':)',
  'sad' : ':(',
  'nothing' : ':|'
 }
}
