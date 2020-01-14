import { User } from './../../model/model.user';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class UserService {
public host:string="http://localhost/";

  constructor(private http:HttpClient) { }
  
  insertUser(user:User){
    return this.http.post(this.host+"API/Orgas/add", user);
  }
  
}
