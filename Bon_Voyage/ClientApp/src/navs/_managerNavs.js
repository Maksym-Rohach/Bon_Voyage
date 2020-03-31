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
            name: 'Білети',
            url: '/base/carousels',
            icon: 'icon-plane',

            children: [
                {
                    name: 'Усі білети',
                    url: '/base/carousels',
                    icon: 'icon-list',
                },
                {
                    name: 'Добавити білет',
                    url: '/base/cards',
                    icon: 'icon-plus',
                },
                {
                    name: 'Куплені білети',
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
