'use strict';

// external
import angular from 'angular';
import UiRouter from 'angular-ui-router';

// // angular module
 import PhotoAlbumModule from '../modules/photo-album.module';
 import DataModule from '../modules/data.module';

// config
import Routes from '../configs/routes.config';

// controllers

import LoginController from '../controllers/authentication/login.controller';
import RegistrationController from '../controllers/authentication/registration.controller';
import LayoutController from '../controllers/base/layout.controller';

// services
import UserDataService from '../services/user-data.service';
import AuthenticationService from '../services/authentication.service';

// components
import UserDataComponent from '../components/user-data.component';
import LoginComponent from '../components/authentication/login.component';
import RegistrationComponent from '../components/authentication/registration.component';
import LayoutComponent from '../components/base/layout.component';
