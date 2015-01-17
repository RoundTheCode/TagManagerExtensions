(function (win, dataLayer) {

    var dataLayer = dataLayer || [];

    var TagManagerExtensions = {
        // Settings begin.
            MacroName: {
                CustomEvent: "event", // The macro name of the custom event to send tracking to Google Tag Manager.
                WebPropertyId: "webPropertyId", // The macro name of the web property ID to send tracking to Google Analytics. 
                VirtualPagePath: "virtualPagePath", // The macro name if the page path is overwritten when sending tracking to Google Analytics.
                CustomDimension: {
                    Value: "cd{n}Value" // The macro name of the custom dimension value. The {n} is replaced by the index number of the custom dimension.
                },
                CustomMetric: {
                    Value: "cm{n}Value" // The macro name of the custom metric value. The {n} is replaced by the index number of the custom metric.
                },
                Pageview: {
                    CustomEventCommand: "firePageview" // The value of the custom event used to fire page view tracking to Google Analytics.
                },
                Event: {
                    CustomEventCommand: "fireEvent", // The value of the custom event used to fire event tracking to Google Analytics.
                    Category: "eventCategory", // The macro name of the event category.
                    Action: "eventAction", // The macro name of the event action.
                    Label: "eventLabel", // The macro name of the event label.
                    Value: "eventValue", // The macro name of the event value.
                    NonInteraction: "eventNonInteraction" // The macro name of the event non interaction.
                },
                Social: {
                    CustomEventCommand: "fireSocial", // The value of the custom event used to fire social tracking to Google Analytics.
                    Network: "socialNetwork", // The macro name of the social network.
                    Action: "socialAction", // The macro name of the social action.
                    Target: "socialTarget" // The macro name of the social target.
                },
                Transaction: {
                    CustomEventCommand: "fireTransaction", // The value of the custom event used to fire transaction tracking to Google Analytics.
                    Currency: "transactionCurrency", // The macro name of the transaction currency.
                    TransactionId: "transactionId", // The macro name of the transaction ID. This would not normally need to change as Google Tag Manager has predefined macro names for transaction tracking.
                    Affiliation: "transactionAffiliation", // The macro name of the transaction affiliation. This would not normally need to change as Google Tag Manager has predefined macro names for transaction tracking.
                    Total: "transactionTotal", // The macro name of the transaction total. This would not normally need to change as Google Tag Manager has predefined macro names for transaction tracking.
                    Shipping: "transactionShipping", // The macro name of the transaction shipping. This would not normally need to change as Google Tag Manager has predefined macro names for transaction tracking.
                    Tax: "transactionTax", // The macro name of the transaction tax. This would not normally need to change as Google Tag Manager has predefined macro names for transaction tracking.
                    Products: {
                        Key: "transactionProducts", // The macro name of the transaction products. This would not normally need to change as Google Tag Manager has predefined macro names for transaction tracking.
                        TransactionId: "transactionId", // The macro name of the transaction ID. This would not normally need to change as Google Tag Manager has predefined macro names for transaction tracking.
                        Name: "name", // The macro name of the product name. This would not normally need to change as Google Tag Manager has predefined macro names for transaction tracking.
                        Sku: "SKU", // The macro name of the product SKU. This would not normally need to change as Google Tag Manager has predefined macro names for transaction tracking.
                        Category: "category", // The macro name of the product category. This would not normally need to change as Google Tag Manager has predefined macro names for transaction tracking.
                        Price: "price", // The macro name of the product price. This would not normally need to change as Google Tag Manager has predefined macro names for transaction tracking.
                        Quantity: "quantity" // The macro name of the product quantity. This would not normally need to change as Google Tag Manager has predefined macro names for transaction tracking.
                    }
                }
                // Settings end.
            },
            VirtualPagePath: undefined,
            KeyValuePush: function (key, value) {
                var KeyValue = {};

                KeyValue[key] = [];
                KeyValue[key] = value;

                this.ObjectPush(KeyValue);
            },
            ObjectPush: function (object) {
                dataLayer.push(object);
            },
            SetWebPropertyId: function (value) {
                this.KeyValuePush(this.MacroName.WebPropertyId, value);
            },
            SetVirtualPagePath: function (value) {
                this.KeyValuePush(this.MacroName.VirtualPagePath, value);
                this.VirtualPagePath = value;
            },
            SetCustomDimension: function (keyIndex, value) {
                this.KeyValuePush(this.MacroName.CustomDimension.Value.replace(/{n}/ig, keyIndex), value);
            },
            SetCustomMetric: function (keyIndex, value) {
                this.KeyValuePush(this.MacroName.CustomMetric.Value.replace(/{n}/ig, keyIndex), value);
            },
            FirePageview: function (pagePath) {
                var KeyValue = {};

                KeyValue[this.MacroName.CustomEvent] = [];
                KeyValue[this.MacroName.CustomEvent] = this.MacroName.Pageview.CustomEventCommand;

                KeyValue[this.MacroName.VirtualPagePath] = [];
                KeyValue[this.MacroName.VirtualPagePath] = pagePath;

                this.ObjectPush(KeyValue);

                if (this.VirtualPagePath != undefined) {
                    this.KeyValuePush(this.MacroName.VirtualPagePath, this.VirtualPagePath);
                }
                else if (pagePath != undefined) {
                    this.KeyValuePush(this.MacroName.VirtualPagePath, undefined);
                }

            },
            FireEvent: function (category, action, label, value, nonInteraction) {
                var KeyValue = {};

                KeyValue[this.MacroName.CustomEvent] = [];
                KeyValue[this.MacroName.CustomEvent] = this.MacroName.Event.CustomEventCommand;

                KeyValue[this.MacroName.Event.Category] = [];
                KeyValue[this.MacroName.Event.Category] = category;

                KeyValue[this.MacroName.Event.Action] = [];
                KeyValue[this.MacroName.Event.Action] = action;

                KeyValue[this.MacroName.Event.Label] = [];
                KeyValue[this.MacroName.Event.Label] = label;

                KeyValue[this.MacroName.Event.Value] = [];
                KeyValue[this.MacroName.Event.Value] = value;

                KeyValue[this.MacroName.Event.NonInteraction] = [];
                KeyValue[this.MacroName.Event.NonInteraction] = nonInteraction;


                this.ObjectPush(KeyValue);
            },
            FireSocial: function (network, action, target) {
                var KeyValue = {};

                KeyValue[this.MacroName.CustomEvent] = [];
                KeyValue[this.MacroName.CustomEvent] = this.MacroName.Social.CustomEventCommand;

                KeyValue[this.MacroName.Social.Network] = [];
                KeyValue[this.MacroName.Social.Network] = network;

                KeyValue[this.MacroName.Social.Action] = [];
                KeyValue[this.MacroName.Social.Action] = action;

                KeyValue[this.MacroName.Social.Target] = [];
                KeyValue[this.MacroName.Social.Target] = target;

                this.ObjectPush(KeyValue);
            },
            FireTransaction: function (transactionId, affiliation, total, shipping, tax, currency) {
                var KeyValue = {};

                KeyValue[this.MacroName.CustomEvent] = [];
                KeyValue[this.MacroName.CustomEvent] = this.MacroName.Transaction.CustomEventCommand;

                KeyValue[this.MacroName.Transaction.TransactionId] = [];
                KeyValue[this.MacroName.Transaction.TransactionId] = transactionId;

                KeyValue[this.MacroName.Transaction.Affiliation] = [];
                KeyValue[this.MacroName.Transaction.Affiliation] = affiliation;

                KeyValue[this.MacroName.Transaction.Total] = [];
                KeyValue[this.MacroName.Transaction.Total] = total;

                KeyValue[this.MacroName.Transaction.Shipping] = [];
                KeyValue[this.MacroName.Transaction.Shipping] = shipping;

                KeyValue[this.MacroName.Transaction.Tax] = [];
                KeyValue[this.MacroName.Transaction.Tax] = tax;

                KeyValue[this.MacroName.Transaction.Currency] = [];
                KeyValue[this.MacroName.Transaction.Currency] = currency;

                KeyValue[this.MacroName.Transaction.Products.Key] = [];
                KeyValue[this.MacroName.Transaction.Products.Key] = this.TransactionProducts;

                this.ObjectPush(KeyValue);

                this.TransactionProducts = undefined;
            },
            TransactionProducts: undefined,
            AddTransactionProduct: function (transactionId, name, sku, category, price, quantity) {
                if (this.TransactionProducts == undefined) {
                    this.TransactionProducts = [];
                }

                var KeyValue = {};

                KeyValue[this.MacroName.Transaction.Products.TransactionId] = [];
                KeyValue[this.MacroName.Transaction.Products.TransactionId] = transactionId;

                KeyValue[this.MacroName.Transaction.Products.Name] = [];
                KeyValue[this.MacroName.Transaction.Products.Name] = name;

                KeyValue[this.MacroName.Transaction.Products.Sku] = [];
                KeyValue[this.MacroName.Transaction.Products.Sku] = sku;

                KeyValue[this.MacroName.Transaction.Products.Category] = [];
                KeyValue[this.MacroName.Transaction.Products.Category] = category;

                KeyValue[this.MacroName.Transaction.Products.Price] = [];
                KeyValue[this.MacroName.Transaction.Products.Price] = price;

                KeyValue[this.MacroName.Transaction.Products.Quantity] = [];
                KeyValue[this.MacroName.Transaction.Products.Quantity] = quantity;

                this.TransactionProducts.push(KeyValue);
            }
    }

    win.dataLayer = dataLayer;
    win.TagManagerExtensions = TagManagerExtensions;

}(window, window.dataLayer));

