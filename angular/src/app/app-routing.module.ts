import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { BrandsComponent } from './brands/brands/brands.component';
import { ChallengesComponent } from './challenges/challenges/challenges.component';
import { TricksComponent } from './tricks/tricks/tricks.component';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'brands', component: BrandsComponent, data: { permission: 'Pages.Brands' }, canActivate: [AppRouteGuard] },
                    { path: 'challenges', component: ChallengesComponent, data: { permission: 'Pages.Challenges' }, canActivate: [AppRouteGuard] },
                    { path: 'tricks', component: TricksComponent, data: { permission: 'Pages.Tricks' }, canActivate: [AppRouteGuard] },
                    { path: 'dashboard', component: DashboardComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'about', component: AboutComponent },
                    { path: 'update-password', component: ChangePasswordComponent }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
