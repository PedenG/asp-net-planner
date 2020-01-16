import { User } from './../../model/model.user';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class UserService {
public host:string="https://localhost:16550/";
  json: string;

  constructor(private http:HttpClient) { }
  
  insertUser(user:User){
    const userJson = JSON.stringify(user);
    console.log(userJson );
    return this.http.post(this.host+"API/Orgas/add", userJson );
  }
  
}
