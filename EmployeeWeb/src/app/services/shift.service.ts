import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Shift } from '../models/Shift';
import { Response } from '../models/Response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShiftService {

  private apiUrl = `${environment.ApiUrl}/Shift`;
  private apiUrlGetAllShifts = `${this.apiUrl}/GetAllShifts`;
  constructor(private http: HttpClient) { }

  GetAllShifts(): Observable<Response<Shift[]>> {
    return this.http.get<Response<Shift[]>>(this.apiUrlGetAllShifts);
  }
}
