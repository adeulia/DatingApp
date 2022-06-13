import { Component, OnInit } from '@angular/core';
import { AccountService } from 'app/_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  loggedIn: boolean;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      console.log(Response);
      this.loggedIn = true;
    }, error => {
      console.log(error);
    })
  }

  logout() {
    this.accountService.logout();
    this.loggedIn = false;
    console.log();
  }

  getCurrentUser() {
    this.accountService.currentUser$.subscribe(user => {
      this.loggedIn = !!user;
      console.log();
    }, error => {
      console.log(error);
    })
  }     
}
