import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  public login(values) : Observable<any> {
    return this.http.post("http://localhost:5000/api/users/login", { 
        Username: values.username, Email: values.email, Password: values.password });
  }
  
}
