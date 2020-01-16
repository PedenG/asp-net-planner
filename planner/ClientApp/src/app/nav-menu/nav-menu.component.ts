import { LoginService } from './../service/login.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit{
  isExpanded = false;
  user:String="";
  constructor( private router:Router, public loginService:LoginService) { }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  ngOnInit() {
    this.loginService.loadUser(); 
    if(this.loginService.userAuthentificated.username){
      this.user=this.loginService.userAuthentificated.username;
    }
  
  }
  onLogout(){
    this.loginService.removeToken();
    this.router.navigateByUrl('');
    this.user="";
  }
}
