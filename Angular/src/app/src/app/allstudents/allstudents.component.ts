import { Component } from '@angular/core';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-allstudents',
  templateUrl: './allstudents.component.html',
  styleUrls: ['./allstudents.component.css']
})
export class AllstudentsComponent {
  public students: any;
  
  constructor(private service: StudentService) { }

  ngOnInit(): void {
    this.getStudents();
  }

  private getStudents(): void {
    this.service.getAllStudents().subscribe(result => {
      this.students = result;
      console.log(this.students);
    });
  }
}
