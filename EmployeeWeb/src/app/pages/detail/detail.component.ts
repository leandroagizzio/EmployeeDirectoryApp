import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from '../../models/Employee';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {

  employee!: Employee;
  id!: number;

  constructor(private employeeService: EmployeeService, private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.id = Number(this.activatedRoute.snapshot.paramMap.get('id'));

    this.employeeService.GetEmployee(this.id).subscribe(data => {

      const emp = data.Data;      
      emp.DateCreated = new Date(emp.DateCreated!).toLocaleDateString('en-IE');
      emp.DateUpdated = new Date(emp.DateUpdated!).toLocaleDateString('en-IE');

      this.employee = data.Data;
      //console.log(this.employee);
    });

  }

  ToggleEmployee() {
    this.employeeService.ToggleEmployee(this.id).subscribe(() => {
      this.router.navigate(['']);
    });
  }

}
