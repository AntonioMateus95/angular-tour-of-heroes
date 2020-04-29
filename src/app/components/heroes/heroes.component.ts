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

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.heroService.addHero({ name } as Hero)
      .subscribe(hero => {
        this.heroes.push(hero);
      });
  }

  delete(hero: Hero): void {
    this.heroes = this.heroes.filter(h => h !== hero);
    /* There's really nothing for the component to do with the Observable 
    returned by heroService.delete() but it must subscribe anyway. If you
     neglect to subscribe(), the service will not send the delete request
      to the server. As a rule, an Observable does nothing until something
       subscribes */
    this.heroService.deleteHero(hero).subscribe();
  }

}
