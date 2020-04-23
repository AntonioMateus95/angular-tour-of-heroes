import { Component, OnInit } from '@angular/core';
import { Hero } from '../../interfaces/hero';
import { HeroService } from '../../services/hero.service';
import { MessageService } from '../../services/message.service';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})
export class HeroesComponent implements OnInit {
  heroes: Hero[];

  /* The parameter simultaneously defines a private heroService 
  property and identifies it as a HeroService injection site. */
  constructor(private heroService: HeroService, private messageService: MessageService) { }

  //Angular calls ngOnInit() shortly after creating a component
  //It's a good place to put initialization logic
  ngOnInit(): void {
    this.getHeroes();
  }

  getHeroes(): void {
    //The code below waits for the Observable to emit the array of heroes
    this.heroService.getHeroes().subscribe(heroes => this.heroes = heroes);
  }

}
