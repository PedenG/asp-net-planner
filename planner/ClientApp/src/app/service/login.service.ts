import { HttpClient } from '@angular/common/http';
import { Organisateur } from './../../model/model.organisateur';
import { Injectable } from '@angular/core';

@Injectable()
export class LoginService {
  private users = [
    {id:5, username: 'admin', password: '123', roles:['ADMIN','USER']},
    {id:6, username: 'user1', password: '123', roles:['USER']},
    {id:7, username: 'user2', password: '123', roles:['USER']}
  ]
  public isAuthentificated: boolean;
  public userAuthentificated;
  public token;
  constructor(private http:HttpClient) { }
  public login(username: string, password: string) {
    let user;
    this.users.forEach(u => {
      if (u.username == username && u.password == password) {
        user = u;
        this.token=btoa(JSON.stringify({id:u.id,username:u.username,roles:u.roles}));
      }
    });
    if (user) {
      this.isAuthentificated = true;
      this.userAuthentificated = user;
    }else{
      this.isAuthentificated = false;
      this.userAuthentificated = undefined;
      console.log("echec");
    }
  };

  public isAdmin(){
    if(this.userAuthentificated){
      if(this.userAuthentificated.roles.indexOf('ADMIN')>-1)     
        return true;
      }
    
    return false;
  }
  public saveUser(){
    if(this.userAuthentificated){
      localStorage.setItem('authToken', this.token);
    }
  }
  public loadUser(){
    let t = localStorage.getItem('authToken');
    if (t){
      let user=JSON.parse(atob(t));
      this.userAuthentificated={id: user.id, username: user.username, roles : user.roles};
      this.isAuthentificated=true;
      this.token=t;
    }
    
  }
  removeToken(){
    localStorage.removeItem('authToken');
    this.isAuthentificated=false;
    this.token=undefined;
    this.userAuthentificated=undefined;
  }
  //https://localhost:16550/API/Orgas/5
  getUser(id:number){
    return this.http.get<Organisateur>("https://localhost:16550/API/Orgas/"+id);
  }
  
}
