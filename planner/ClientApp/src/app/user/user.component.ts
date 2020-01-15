import { UserService } from './../service/user.service';
import { Component, OnInit } from '@angular/core';
import { User } from '../../model/model.user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
 user:User=new User();
  constructor(private userService :UserService) { }

  ngOnInit() {
   
  }
  AddUser(){
    console.log(this.user);
    const userJson = JSON.stringify(this.user);
    this.userService.insertUser(this.user)
    .subscribe(data=>{
      console.log("envoyées");
      console.log(data);
    }, err=>{
      console.log(err);
    })
  }
}
