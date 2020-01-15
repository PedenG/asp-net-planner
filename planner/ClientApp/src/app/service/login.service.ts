import { Injectable } from '@angular/core';

@Injectable()
export class LoginService {
  private users = [
    {username: 'admin', password: '123', roles:['ADMIN','USER']},
    {username: 'user1', password: '123', roles:['USER']},
    {username: 'user2', password: '123', roles:['USER']}
  ]
  public isAuthentificated: boolean;
  public userAuthentificated;
  public token;
  constructor() { }
  public login(username: string, password: string) {
    let user;
    this.users.forEach(u => {
      if (u.username == username && u.password == password) {
        user = u;
        this.token=btoa(JSON.stringify({username:u.username,roles:u.roles}));
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
      this.userAuthentificated={username: user.username, roles : user.roles};
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
  
}
