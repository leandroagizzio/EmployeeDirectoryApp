import { Shift } from "./Shift";

export interface Employee {
  Id?: number,
  Name: string;
  Title: string;
  Active: boolean;
  DateCreated?: string;
  DateUpdated?: string;
  ShiftModel?: Shift;
}
