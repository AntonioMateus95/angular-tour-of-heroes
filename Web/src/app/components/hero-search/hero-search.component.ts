import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';

import { Hero } from '../../interfaces/hero';
import { HeroService } from '../../services/hero.service';

@Component({
  selector: 'app-hero-search',
  templateUrl: './hero-search.component.html',
  styleUrls: [ './hero-search.component.css' ]
})
export class HeroSearchComponent implements OnInit {
  heroes$: Observable<Hero[]>;

  /* A Subject is both a source of observable values and an Observable itself.
  You can subscribe to a Subject as you would any Observable. The next() method
  pushes a value to the Subject, so it would be the next value to be processed */
  private searchTerms = new Subject<string>();

  constructor(private heroService: HeroService) {}

  // Push a search term into the observable stream.
  search(term: string): void {
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
    /* */
    this.heroes$ = this.searchTerms.pipe(
      // wait 300ms after each keystroke before considering the term
      debounceTime(300),

      // ignore new term if same as previous term
      distinctUntilChanged(),

      // switch to new search observable each time the term changes
      /* It calls the search service for each search term that makes it
      through the last two operators. It cancels and discards previous
      search observables, returning only the latest one: switchMap()
      preserves the original request order while returning only the
      observable from the most recent HTTP method call; results from prior
      calls are canceled and discarded. */
      switchMap((term: string) => this.heroService.searchHeroes(term)),
    );
  }
}