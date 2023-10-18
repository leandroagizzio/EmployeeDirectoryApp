import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Response } from '../models/Response';
import { Employee } from '../models/Employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private apiUrl = `${environment.ApiUrl}/Employee`;
  private apiUrlGetAllEmployees = `${this.apiUrl}/GetAllEmployees`;
  private apiUrlGetEmployee = `${this.apiUrl}/GetEmployee`;
  private apiUrlInsertEmployee = `${this.apiUrl}/UpsertEmployee`;
  private apiUrlEditEmployee = `${this.apiUrl}/UpsertEmployee`;
  private apiUrlDeleteEmployee = `${this.apiUrl}/DeleteEmployee`;
  private apiUrlToggleEmployee = `${this.apiUrl}/ToggleSituation`;

  constructor(private http: HttpClient) { }

  GetEmployees() : Observable<Response<Employee[]>> {
    return this.http.get<Response<Employee[]>>(this.apiUrlGetAllEmployees);
  }

  GetEmployee(id : number): Observable<Response<Employee>> {
    return this.http.get<Response<Employee>>(`${this.apiUrlGetEmployee}/${id}`);
  }

  CreateEmployee(employee: Employee): Observable<Response<Employee>> {
    return this.http.post<Response<Employee>>(this.apiUrlInsertEmployee, employee);
  }

  EditEmployee(employee: Employee): Observable<Response<Employee>> {
    return this.http.post<Response<Employee>>(this.apiUrlEditEmployee, employee);
  }

  DeleteEmployee(id: number): Observable<Response<boolean>> {
    return this.http.delete<Response<boolean>>(`${this.apiUrlDeleteEmployee}/${id}`);
  }

  ToggleEmployee(id: number): Observable<Response<Employee>> {
    return this.http.put<Response<Employee>>(`${this.apiUrlToggleEmployee}/${id}`, id);
  }

}
