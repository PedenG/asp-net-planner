import { Addcalander } from './../../model/model.add-calander';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AddCalandarService {

  public host:string="https://localhost:16550/";
 

  constructor(private http:HttpClient) { }
  
  insertCalander(addcalander:Addcalander){
    const addcalanderJson = JSON.stringify(addcalander);
    console.log(addcalanderJson);
    return this.http.post(this.host+"API/Events/add", addcalanderJson);
  }
  

}
