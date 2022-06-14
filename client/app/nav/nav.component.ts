import { Component, OnInit } from '@angular/core';
import { User } from 'app/_models/user';
import { AccountService } from 'app/_services/account.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      console.log(Response);
    }, error => {
      console.log(error);
    })
  }

  logout() {
    this.accountService.logout();
    console.log();
  }     
}
