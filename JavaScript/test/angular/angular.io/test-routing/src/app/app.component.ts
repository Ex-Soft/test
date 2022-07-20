import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'test-routing';
  page1route = ["/"];
  page2route = ["/"];
  timeoutId!: number;

  constructor(private router: Router) {
  }

  ngOnInit() {
  }

  onClick(pageNumber: number): boolean {
    const route = pageNumber === 1 ? this.page1route : this.page2route;

    if (route.length === 1) {
      this.timeoutId = window.setTimeout(() => {
        route.push("page" + pageNumber);
        clearTimeout(this.timeoutId);
        console.log(route);
        this.router.navigate(route);
      }, 5000);
      return false;
    }

    return true;
  }
}
