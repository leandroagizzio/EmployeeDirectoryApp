import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/Employee';
import { EmployeeService } from '../../services/employee.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  btnActionName: string = 'Edit';
  btnTitleName = 'Edit an employee';
  employee!: Employee;

  constructor(private employeeService: EmployeeService, private activatedRoute : ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    const id = Number(this.activatedRoute.snapshot.paramMap.get('id'));


    this.employeeService.GetEmployee(id).subscribe(data => {
      this.employee = data.Data;
      
    });

  }

  editEmployee(employee: Employee) {
    this.employeeService.EditEmployee(employee).subscribe(() => {
      this.router.navigate(['/']);
    });

  }


}
