import { Component, OnInit } from '@angular/core';
import moment = require('moment');


@Component({
  selector: 'app-add-calendar',
  templateUrl: './add-calendar.component.html',
  styleUrls: ['./add-calendar.component.css']
})
export class AddCalendarComponent implements OnInit {

  private listDays = [];
  private numWeek = 1;
  constructor() {
    
   }

  ngOnInit() {
    this.getListOfDayByWeekNumber();
  }

  private getListOfDayByWeekNumber(){
    this.numWeek = moment().isoWeek();

    
  }

}
