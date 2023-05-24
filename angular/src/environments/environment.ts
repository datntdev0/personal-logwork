import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'PersonalLogwork',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44333/',
    redirectUri: baseUrl,
    clientId: 'PersonalLogwork_App',
    responseType: 'code',
    scope: 'offline_access PersonalLogwork',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44333',
      rootNamespace: 'datntdev.PersonalLogwork',
    },
  },
} as Environment;
