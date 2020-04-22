import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { Hero } from '../interfaces/hero';
import { HEROES } from '../mocks/mock-heroes';

//Injectable decorator: marks the class as one that participates in the DI system
//This decorator accepts a metadata object for the service
/* A provider is something that can create or deliver a service; in that case, it
instantiates the HeroService class to provide the service */
/* injector: is the object that is responsible for choosing and injecting the provider
where the app requires it*/
/* When you provide the service at the root level, Angular creates a single, shared 
instance of HeroService and injects into any class that asks for it. Registering the 
provider in the @Injectable metadata also allows Angular to optimize an app by removing 
the service if it turns out not to be used after all.  */
@Injectable({
  providedIn: 'root' //injector
})

export class HeroService {

  constructor() { }

  getHeroes(): Observable<Hero[]> {
    return of(HEROES);
  }
}
