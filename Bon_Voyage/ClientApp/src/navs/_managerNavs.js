export default {
    items: [
        {
            title: true,
            name: 'Меню',
            wrapper: {            // optional wrapper object
                element: '',        // required valid HTML5 element tag
                attributes: {}        // optional valid JS object with JS API naming ex: { className: "my-class", style: { fontFamily: "Verdana" }, id: "my-id"}
            },
            class: ''             // optional class names space delimited list for title item ex: "text-center"
        },
        {
            name: 'Профіль',
            url: '/manager/profile',
            icon: 'icon-user',
        },
        {
            name: 'Квитки',
            url: '/base/carousels',
            icon: 'icon-plane',

            children: [
                {
                    name: 'Усі квитки',
                    url: '/base/carousels',
                    icon: 'icon-list',
                },
                {
                    name: 'Додати квитки',
                    url: '/manager/ticket/add',
                    icon: 'icon-plus',
                },
                {
                    name: 'Куплені квитки',
                    url: '/base/carousels',
                    icon: 'icon-credit-card',
                },
                {
                    name: 'Гарячі пропозиції',
                    url: '/base/carousels',
                    icon: 'icon-fire',
                }
            ]
        }
    ]
};
