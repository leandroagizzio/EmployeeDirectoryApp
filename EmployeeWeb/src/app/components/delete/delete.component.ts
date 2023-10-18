import { Component, OnInit, Inject } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Employee } from '../../models/Employee';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  inputData: any;
  employee!: Employee;

  constructor(
    private employeeService: EmployeeService,
    private router: Router,
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    @Inject(MAT_DIALOG_DATA) public data: any,
    private ref: MatDialogRef<DeleteComponent>
  ) { }

  ngOnInit(): void {
    this.inputData = this.data;

    this.employeeService.GetEmployee(this.inputData.id).subscribe((response) => {
      this.employee = response.Data;
    });


  }

  Delete() {
    this.employeeService.DeleteEmployee(this.inputData.id).subscribe((response) => {
      if (!response.IsSuccess) {
        // error
      }
      this.CloseDialog();
      window.location.reload();
    });
  }

  CloseDialog() {
    this.ref.close();
  }

}
