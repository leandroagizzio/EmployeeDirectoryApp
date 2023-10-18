import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/Employee';
import { MatDialog } from '@angular/material/dialog';
import { DeleteComponent } from '../../components/delete/delete.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  employees: Employee[] = [];
  employeesAll: Employee[] = [];

  columnsMap = ['Situation', 'Name', 'Title', 'Shift', 'Actions', 'Delete']; 

  constructor(private employeeService: EmployeeService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.employeeService.GetEmployees().subscribe(data => {

      const lista = data.Data;

      lista?.map((item) => {
        item.DateCreated = new Date(item.DateCreated!).toLocaleDateString('en-IE');
        item.DateUpdated = new Date(item.DateUpdated!).toLocaleDateString('en-IE');
      });
      
      this.employees = lista;
      this.employeesAll = lista;

    });
  }

  search(event : Event) {
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();

    this.employees = this.employeesAll.filter(emp => {
      return emp.Name.toLowerCase().includes(value);
    });

  }

  OpenDialog(id : number) {
    this.dialog.open(DeleteComponent, {
      width: '450px',
      height: '450px',
      data: {
        id: id
      }
    });
  }

}
