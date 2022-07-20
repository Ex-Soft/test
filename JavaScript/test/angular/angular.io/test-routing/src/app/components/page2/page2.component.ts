import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page2',
  templateUrl: './page2.component.html',
  styleUrls: ['./page2.component.css']
})
export class Page2Component implements OnInit {
  page1route: string[] = [];
  timeoutId!: number;

  constructor(private router: Router) {}

  ngOnInit(): void {
  }
  
  onClick(pageNumber: number): boolean {
    if (!this.page1route.length) {
      this.timeoutId = window.setTimeout(() => {
        this.page1route.push("/");
        this.page1route.push("page" + pageNumber);
        clearTimeout(this.timeoutId);
        console.log(this.page1route);
        this.router.navigate(this.page1route);
      }, 5000);
      return false;
    }

    return true;
  }
}
