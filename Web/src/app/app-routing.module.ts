import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeroesComponent } from './components/heroes/heroes.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HeroDetailComponent } from './components/hero-detail/hero-detail.component';

//command for generating this module in angular cli: ng generate module app-routing --flat --module=app
//--flat puts the file in src/app instead of its own folder
//--module=app tells the CLI to register it in the imports array of the AppModule

//routes' configuration:
//Routes tell the Router which view to display when a user clicks a link or pastes a URL into the browser
//address bar
const routes: Routes = [
  //Route has two properties: path (URL) and component (component that the router should create when
  //navigating to this route) 
  //The first route redirects a URL that fully matches the empty path to the route whose path is '/dashboard'
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'heroes', component: HeroesComponent },
  { path: 'dashboard', component: DashboardComponent },
  //Parameterized route. The colon (:) in the path indicates that :id is a placeholder for a specific hero id
  { path: 'detail/:id', component: HeroDetailComponent }
];

@NgModule({
  /* the RouterModule is added to the AppRoutingModule imports array and is configured with the routes array
  in one step by forRoot() call (the router is configured at the application's root level) */
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
