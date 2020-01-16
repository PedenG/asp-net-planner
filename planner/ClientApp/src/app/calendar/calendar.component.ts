import { LoginService } from './../service/login.service';
import { Component, OnInit } from '@angular/core';
import moment = require('moment');

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  private listDays = [];
  private numWeek = moment().isoWeek();
  private curentDate;
  private listOfHours = [{
    name : "00h00 - 02H00",
    
  },{
    name : "02h00 - 04H00",
  },{
    name : "04h00 - 06H00",
    
  },{
    name : "06h00 - 08H00",
  },{
    name : "08h00 - 10H00",
    
  },{
    name : "10h00 - 12H00",
  },{
    name : "12h00 - 14H00",
    
  },{
    name : "14h00 - 16H00",
  },{
    name : "16h00 - 18H00",
    
  },{
    name : "18h00 - 20H00",
  },{
    name : "20h00 - 22H00",
    
  },{
    name : "22h00 - 24H00",
  }]
  constructor(public loginService:LoginService) {
    
   }

  ngOnInit() {
    this.getListOfDayByWeekNumber();
    this.loginService.loadUser(); 
  }

  private getListOfDayByWeekNumber(){
    this.curentDate = moment().day("Monday").week(this.numWeek);
    this.listDays = [];
    for(let  i = 1; i < 8; i++){
        this.listDays.push(moment(this.curentDate).day(i).format('DD/MM'));
    }
    this.curentDate = moment(this.curentDate).format('YYYY-MM-DD');
  }

  private decrementWeek(){
    this.numWeek--;
    this.getListOfDayByWeekNumber();
  }

  private incrementWeek(){
    this.numWeek++;
    this.getListOfDayByWeekNumber();
  }
}
