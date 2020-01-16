import { LoginService } from './../service/login.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-list-calendar',
  templateUrl: './list-calendar.component.html',
  styleUrls: ['./list-calendar.component.css']
})
export class ListCalendarComponent implements OnInit {

  public listeEvent;
  constructor(private http : HttpClient, public loginService:LoginService) { }

  ngOnInit() {
    this.getEvents();
    this.loginService.loadUser();
   
  }

  private getEvents(){
    this.http.get("https://localhost:16550/API/Events").subscribe( data => {
      this.listeEvent = data;
      console.log(this.listeEvent);
    });
  }
 

}
