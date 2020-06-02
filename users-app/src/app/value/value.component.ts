import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  url = 'http://localhost:5000/api/users';
  users: any;
  userLoaded=false;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getValues();
  }
getValues(){
  this.http.get(this.url).subscribe(response => {
    this.users = response;
    this.userLoaded = true;
  });

}
}
