export interface Response<T> {
  IsSuccess: boolean;
  Message: string;
  Data: T;
}
