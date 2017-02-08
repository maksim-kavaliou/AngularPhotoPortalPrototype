'use strict';

import { LayoutController } from '../../controllers/base/layout.controller';

var LayoutComponent =  {
  controller: LayoutController,
  templateUrl: 'src/view/components/base/layout.html'
};

angular.module('PhotoAlbum')
.component('layout', LayoutComponent);

export { LayoutComponent };
