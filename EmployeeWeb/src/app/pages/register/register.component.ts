import { Component } from '@angular/core';
import { Employee } from '../../models/Employee';
import { EmployeeService } from '../../services/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  btnActionName = 'Register';
  btnTitleName = 'Register new Employee';

  constructor(private employeeService: EmployeeService, private router: Router) { }

  createEmployee(employee: Employee) {
    this.employeeService.CreateEmployee(employee).subscribe(() => {
      this.router.navigate(['/']);
    });
  }

}
