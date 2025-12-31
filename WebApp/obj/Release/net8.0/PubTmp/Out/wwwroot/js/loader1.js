const LoaderInProgress = {
    __loader: null,
    show: function () {

        if (this.__loader == null) {
            var divContainer = document.createElement('div');
            divContainer.style.position = 'fixed';
            divContainer.style.left = '0';
            divContainer.style.top = '0';
            divContainer.style.width = '100%';
            divContainer.style.height = '100%';
            divContainer.style.zIndex = '9998';
            divContainer.style.backgroundColor = 'rgba(250, 250, 250, 0.80)';

            var divMaster = document.createElement('div');
            divMaster.style.margin = '15% 40%';
            divContainer.appendChild(divMaster);

            var wheel = document.createElement('div');
            wheel.style.height = '64px';
            wheel.style.width = '64px';
            wheel.style.border = '8px solid #e1e1e1';
            wheel.style.borderRadius = '50%';
            wheel.style.borderTop = '8px solid #638CA6';
            wheel.animate([
                { transform: 'rotate(0deg)' },
                { transform: 'rotate(360deg)' }
            ], {
                duration: 1300,
                iterations: Infinity
            });
            divMaster.appendChild(wheel);

            var tesxtDiv = document.createElement('div');
            tesxtDiv.textContent = "Scan In Progress...";
            divMaster.appendChild(tesxtDiv);

            this.__loader = divContainer
            document.body.appendChild(this.__loader);
        }
        this.__loader.style.display = "";
    },
    hide: function () {
        if (this.__loader != null) {
            this.__loader.style.display = "none";
        }
    }
}
const Loader = {
    __loader: null,
    show: function () {

        if (this.__loader == null) {
            var divContainer = document.createElement('div');
            divContainer.style.position = 'fixed';
            divContainer.style.left = '0';
            divContainer.style.top = '0';
            divContainer.style.width = '100%';
            divContainer.style.height = '100%';
            divContainer.style.zIndex = '9998';
            divContainer.style.backgroundColor = '#00000096';

            var div = document.createElement('div');
            div.style.position = 'absolute';
            div.style.left = '50%';
            div.style.top = '50%';
            div.style.zIndex = '9999';
            div.style.height = '64px';
            div.style.width = '64px';
            div.style.margin = '-76px 0 0 -76px';
            div.style.border = '8px solid #e1e1e1';
            div.style.borderRadius = '50%';
            div.style.borderTop = '8px solid #638CA6';
            div.animate([
                { transform: 'rotate(0deg)' },
                { transform: 'rotate(360deg)' }
            ], {
                duration: 1300,
                iterations: Infinity
            });
            divContainer.appendChild(div);
            this.__loader = divContainer
            document.body.appendChild(this.__loader);
        }
        this.__loader.style.display = "";
    },
    hide: function () {
        if (this.__loader != null) {
            this.__loader.style.display = "none";
        }
    }
}