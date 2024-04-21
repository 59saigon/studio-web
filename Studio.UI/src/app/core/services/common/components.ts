export type ComponentCardItem = {
  className: string;
  images: { light: string; dark: string };
};

export type RouteProps = {
  title: string;
  icon: string;
  href: string;
  group: boolean;
  card?: ComponentCardItem;
};

export const components: RouteProps[] = [
  {
    title: 'Dashboard Management',
    href: 'dashboard-management',
    group: false,
    icon: `<svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m4 12 8-8 8 8M6 10.5V19a1 1 0 0 0 1 1h3v-3a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v3h3a1 1 0 0 0 1-1v-8.5"/>
  </svg>
  `,
  },
  {
    title: 'Wedding Management',
    href: 'wedding-management',
    group: false,
    icon: `<svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12.01 6.001C6.5 1 1 8 5.782 13.001L12.011 20l6.23-7C23 8 17.5 1 12.01 6.002Z"/>
  </svg>
  
  `,
  },
  {
    title: 'Event Management',
    href: 'event-management',
    group: false,
    icon: `<svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m11.5 11.5 2.071 1.994M4 10h5m11 0h-1.5M12 7V4M7 7V4m10 3V4m-7 13H8v-2l5.227-5.292a1.46 1.46 0 0 1 2.065 2.065L10 17Zm-5 3h14a1 1 0 0 0 1-1V7a1 1 0 0 0-1-1H5a1 1 0 0 0-1 1v12a1 1 0 0 0 1 1Z"/>
  </svg>
  `,
  },
  {
    title: 'Photo Management',
    href: 'photo-management',
    group: false,
    icon: `<svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
    <path stroke="currentColor" stroke-linejoin="round" stroke-width="2" d="M4 18V8a1 1 0 0 1 1-1h1.5l1.707-1.707A1 1 0 0 1 8.914 5h6.172a1 1 0 0 1 .707.293L17.5 7H19a1 1 0 0 1 1 1v10a1 1 0 0 1-1 1H5a1 1 0 0 1-1-1Z"/>
    <path stroke="currentColor" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z"/>
  </svg>
  `,
  },
  {
    title: 'Service Management',
    href: 'service-management',
    group: false,
    icon: `<svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 8h.01M9 8h.01M12 8h.01M4 11h16M4 19h16a1 1 0 0 0 1-1V6a1 1 0 0 0-1-1H4a1 1 0 0 0-1 1v12a1 1 0 0 0 1 1Z"/>
  </svg>
  `,
  },
  {
    title: 'User Management',
    href: 'user-management',
    group: false,
    icon: `<svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
    <path stroke="currentColor" stroke-linecap="square" stroke-linejoin="round" stroke-width="2" d="M10 19H5a1 1 0 0 1-1-1v-1a3 3 0 0 1 3-3h2m10 1a3 3 0 0 1-3 3m3-3a3 3 0 0 0-3-3m3 3h1m-4 3a3 3 0 0 1-3-3m3 3v1m-3-4a3 3 0 0 1 3-3m-3 3h-1m4-3v-1m-2.121 1.879-.707-.707m5.656 5.656-.707-.707m-4.242 0-.707.707m5.656-5.656-.707.707M12 8a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z"/>
  </svg>
  `,
  },

  // {
  //   title: 'Auth',
  //   icon: '<svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 20 20" class="h-6 w-6 text-gray-500 transition duration-75 group-hover:text-gray-900 dark:text-gray-400 dark:group-hover:text-white" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M4 4a2 2 0 00-2 2v1h16V6a2 2 0 00-2-2H4z"></path><path fill-rule="evenodd" d="M18 9H2v5a2 2 0 002 2h12a2 2 0 002-2V9zM4 13a1 1 0 011-1h1a1 1 0 110 2H5a1 1 0 01-1-1zm5-1a1 1 0 100 2h1a1 1 0 100-2H9z" clip-rule="evenodd"></path></svg>',
  //   href: '/auth',
  //   group: false,
  //   card: {
  //     className: 'w-56',
  //     images: { light: 'accordion-light.svg', dark: 'accordion-dark.svg' },
  //   },
  // },
  // {
  //   title: 'Crud',
  //   icon: '<svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 20 20" class="h-6 w-6 text-gray-500 transition duration-75 group-hover:text-gray-900 dark:text-gray-400 dark:group-hover:text-white" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M10 2a6 6 0 00-6 6v3.586l-.707.707A1 1 0 004 14h12a1 1 0 00.707-1.707L16 11.586V8a6 6 0 00-6-6zM10 18a3 3 0 01-3-3h6a3 3 0 01-3 3z"></path></svg>',
  //   href: '/crud',
  //   group: false,
  //   card: {
  //     className: 'w-56',
  //     images: { light: 'alerts-light.svg', dark: 'alerts-dark.svg' },
  //   },
  // },
  // {
  //   title: 'Indicator',
  //   // create icon gray circular svg
  //   icon: '<svg width="10" height="10"><circle cx="5" cy="5" r="4" stroke="#ccc" stroke-width="1" fill="#ccc"/></svg>    ',
  //   href: '/indicators',
  //   group: false,
  //   card: {
  //     className: 'w-56',
  //     images: { light: 'indicators.svg', dark: 'indicators-dark.svg' },
  //   },
  // },
  // {
  //   title: 'Badges',
  //   href: 'badges',
  //   group: false,
  //   card: {
  //     className: 'w-28',
  //     images: { light: 'badges-light.svg', dark: 'badges-dark.svg' },
  //   },
  //   icon: `<svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 20 20" class="h-6 w-6 text-gray-500 transition duration-75 group-hover:text-gray-900 dark:text-gray-400 dark:group-hover:text-white" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M6.267 3.455a3.066 3.066 0 001.745-.723 3.066 3.066 0 013.976 0 3.066 3.066 0 001.745.723 3.066 3.066 0 012.812 2.812c.051.643.304 1.254.723 1.745a3.066 3.066 0 010 3.976 3.066 3.066 0 00-.723 1.745 3.066 3.066 0 01-2.812 2.812 3.066 3.066 0 00-1.745.723 3.066 3.066 0 01-3.976 0 3.066 3.066 0 00-1.745-.723 3.066 3.066 0 01-2.812-2.812 3.066 3.066 0 00-.723-1.745 3.066 3.066 0 010-3.976 3.066 3.066 0 00.723-1.745 3.066 3.066 0 012.812-2.812zm7.44 5.252a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z" clip-rule="evenodd"></path></svg>`,
  // },
  // {
  //   title: 'Breadcrumb',
  //   icon: '<svg class="w-6 h-6" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M10.293 15.707a1 1 0 010-1.414L14.586 10l-4.293-4.293a1 1 0 111.414-1.414l5 5a1 1 0 010 1.414l-5 5a1 1 0 01-1.414 0z" clip-rule="evenodd"></path><path fill-rule="evenodd" d="M4.293 15.707a1 1 0 010-1.414L8.586 10 4.293 5.707a1 1 0 011.414-1.414l5 5a1 1 0 010 1.414l-5 5a1 1 0 01-1.414 0z" clip-rule="evenodd"></path></svg>',
  //   href: '/breadcrumb',
  //   group: false,
  //   card: {
  //     className: 'w-56',
  //     images: { light: 'breadcrumb-light.svg', dark: 'breadcrumb-dark.svg' },
  //   },
  // },
  // {
  //   title: 'Buttons',
  //   icon: '<svg fill="currentColor" viewBox="0 0 20 20" class="h-6 w-6 text-gray-500 transition duration-75 group-hover:text-gray-900 dark:text-gray-400 dark:group-hover:text-white" xmlns="http://www.w3.org/2000/svg"><path d="M7 3a1 1 0 000 2h6a1 1 0 100-2H7zM4 7a1 1 0 011-1h10a1 1 0 110 2H5a1 1 0 01-1-1zM2 11a2 2 0 012-2h12a2 2 0 012 2v4a2 2 0 01-2 2H4a2 2 0 01-2-2v-4z"></path></svg>',
  //   href: '/buttons',
  //   group: false,
  //   card: {
  //     className: 'w-24',
  //     images: { light: 'buttons.svg', dark: 'buttons.svg' },
  //   },
  // },
  // {
  //   title: 'Dropdown',
  //   icon: '<svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 20 20" aria-hidden="true" data-testid="flowbite-sidebar-item-icon" class="h-6 w-6 flex-shrink-0 text-gray-500 transition duration-75 group-hover:text-gray-900 dark:text-gray-400 dark:group-hover:text-white" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm1-11a1 1 0 10-2 0v3.586L7.707 9.293a1 1 0 00-1.414 1.414l3 3a1 1 0 001.414 0l3-3a1 1 0 00-1.414-1.414L11 10.586V7z" clip-rule="evenodd"></path></svg>',
  //   href: '/dropdown',
  //   group: false,
  //   card: {
  //     className: 'w-28',
  //     images: { light: 'dropdown-light.svg', dark: 'dropdown-dark.svg' },
  //   },
  // },
  // {
  //   title: 'Forms',
  //   icon: '<svg fill="none" class="h-6 w-6 text-gray-500 transition duration-75 group-hover:text-gray-900 dark:text-gray-400 dark:group-hover:text-white" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" aria-hidden="true"><path stroke-linecap="round" stroke-linejoin="round" d="M3.75 9h16.5m-16.5 6.75h16.5"></path></svg>',
  //   href: '/forms',
  //   group: false,
  //   card: {
  //     className: 'w-56',
  //     images: { light: 'forms.svg', dark: 'forms-dark.svg' },
  //   },
  // },
  // {
  //   title: 'Input Field',
  //   icon: '<svg fill="none" class="h-6 w-6 text-gray-500 transition duration-75 group-hover:text-gray-900 dark:text-gray-400 dark:group-hover:text-white" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" aria-hidden="true"><path stroke-linecap="round" stroke-linejoin="round" d="M3.75 9h16.5m-16.5 6.75h16.5"></path></svg>',
  //   href: '/input-field',
  //   group: false,
  //   card: {
  //     className: 'w-56',
  //     images: { light: 'forms.svg', dark: 'forms-dark.svg' },
  //   },
  // },
  // {
  //   title: 'Floating Label',
  //   icon: '<svg fill="none" class="h-6 w-6 text-gray-500 transition duration-75 group-hover:text-gray-900 dark:text-gray-400 dark:group-hover:text-white" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" aria-hidden="true"><path stroke-linecap="round" stroke-linejoin="round" d="M3.75 9h16.5m-16.5 6.75h16.5"></path></svg>',
  //   href: '/floating-label',
  //   group: false,
  //   card: {
  //     className: 'w-56',
  //     images: { light: 'forms.svg', dark: 'forms-dark.svg' },
  //   },
  // },
  // {
  //   title: 'Modals',
  //   href: 'modals',
  //   group: false,
  //   card: {
  //     className: 'w-56',
  //     images: { light: 'modal-light.svg', dark: 'modal-dark.svg' },
  //   },
  //   icon: `<svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 20 20" aria-hidden="true" class="h-6 w-6 text-gray-500 transition duration-75 group-hover:text-gray-900 dark:text-gray-400 dark:group-hover:text-white" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M6 2a2 2 0 00-2 2v12a2 2 0 002 2h8a2 2 0 002-2V4a2 2 0 00-2-2H6zm4 14a1 1 0 100-2 1 1 0 000 2z" clip-rule="evenodd"></path></svg>`,
  // },
  // {
  //   title: 'Sidebar',
  //   href: 'sidebar',
  //   group: false,
  //   card: {
  //     className: 'w-16',
  //     images: { light: 'sidebar-light.svg', dark: 'sidebar-dark.svg' },
  //   },
  //   icon: `<svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 448 512" class="h-6 w-6 text-gray-500 transition duration-75 group-hover:text-gray-900 dark:text-gray-400 dark:group-hover:text-white" height="1em" width="1em" xmlns="http://www.w3.org/2000/svg"><path d="M16 132h416c8.837 0 16-7.163 16-16V76c0-8.837-7.163-16-16-16H16C7.163 60 0 67.163 0 76v40c0 8.837 7.163 16 16 16zm0 160h416c8.837 0 16-7.163 16-16v-40c0-8.837-7.163-16-16-16H16c-8.837 0-16 7.163-16 16v40c0 8.837 7.163 16 16 16zm0 160h416c8.837 0 16-7.163 16-16v-40c0-8.837-7.163-16-16-16H16c-8.837 0-16 7.163-16 16v40c0 8.837 7.163 16 16 16z"></path></svg>`,
  // },
];
