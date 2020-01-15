import { LoginService } from './../service/login.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-list-calendar',
  templateUrl: './list-calendar.component.html',
  styleUrls: ['./list-calendar.component.css']
})
export class ListCalendarComponent implements OnInit {

  private listeEvent;
  constructor(private http : HttpClient, public loginService:LoginService) { }

  ngOnInit() {
    this.getEvents();
    this.loginService.loadUser();
   
  }

  private getEvents(){
    this.http.get("http://localhost:51764/api/Events").subscribe( data => {
      this.listeEvent = data;
    });
  }
 

}
