import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Hero } from '../../interfaces/hero';
import { HeroService } from '../../services/hero.service';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: ['./hero-detail.component.css']
})
export class HeroDetailComponent implements OnInit {

  @Input() hero: Hero;

  constructor(
    //ActivatedRoute holds information about the route to this instance of HeroDetailComponent
    private route: ActivatedRoute,
    private heroService: HeroService,
    //Location is an Angular service for interacting with the browser
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getHero();
  }

  getHero(): void {
    //Route.snapshot is a static image of the route into shortly after the component was created
    //paramMap is a dictionary of route parameter values extracted from the URL
    //Route parameters are always strings. + is a JS operator that converts string to number OMG
    const id = +this.route.snapshot.paramMap.get('id');
    this.heroService.getHero(id)
      .subscribe(hero => this.hero = hero);
  }

  goBack(): void {
    this.location.back();
  }

}
