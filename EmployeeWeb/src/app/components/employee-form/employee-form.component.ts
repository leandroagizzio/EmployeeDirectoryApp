import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ShiftService } from '../../services/shift.service';
import { Shift } from '../../models/Shift';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Employee } from '../../models/Employee';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {

  @Output() onSubmit = new EventEmitter<Employee>();
  @Input() btnActionName!: string;
  @Input() btnTitleName!: string;
  @Input() dataEmployee: Employee | null = null;

  shifts: Shift[] = [];
  employeeForm!: FormGroup;
  //selShift?: number = 0;

  constructor(private shiftService: ShiftService) { }

  ngOnInit(): void {
    this.shiftService.GetAllShifts().subscribe(data => {
      this.shifts = data.Data;
    });

    //console.log('shifsts');
    //console.log(this.dataEmployee?.ShiftModel);
    //this.selShift = this.dataEmployee ? this.dataEmployee.ShiftModel?.Id : 0;

    this.employeeForm = new FormGroup({
      id: new FormControl(this.dataEmployee ? this.dataEmployee.Id : 0),
      name: new FormControl(this.dataEmployee ? this.dataEmployee.Name : '', [Validators.required]),
      title: new FormControl(this.dataEmployee ? this.dataEmployee.Title : '', [Validators.required]),
      active: new FormControl(this.dataEmployee ? this.dataEmployee.Active : true),
      dateCreated: new FormControl(new Date()),
      dateUpdated: new FormControl(new Date()),
      shiftModel: new FormGroup({
        id: new FormControl(this.dataEmployee ? this.dataEmployee.ShiftModel?.Id : 0, [Validators.min(1)]),
        name: new FormControl(this.dataEmployee ? this.dataEmployee.ShiftModel?.Name : '')
      })
    });

  }

  submit() {
    this.onSubmit.emit(this.employeeForm.value);
  }

}
