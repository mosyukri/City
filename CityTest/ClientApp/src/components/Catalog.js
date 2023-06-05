import React, { Component } from 'react';

export class Catalog extends Component {
    static displayName = Catalog.name;
    constructor(props) {
        super(props);
        this.state = {
            product: [], loading: true, currency: "AUD",


            currencyRate: 1,
            rate : []
        };
    }
    updatePrice = (val) => {
      

            setState({ currency: val })
  

    }
    //first run when page loaded
    componentDidMount() {

        //this.populatepriceData();
        this.populateProductData();
    }

    async populateProductData() {
        const response = await fetch('product');
        const data = await response.json();
        this.setState({ product: data, loading: false });
    }
    async populatepriceData() {

        const response = await fetch('product/price?fromprice=' + this.state.currency);
        const data = await response.json();
        this.setState({ rate: data, loading: false });

    }

    
    static renderProduct(product) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th style={{ width:"10%" }}>Name</th>
                        <th>Description</th>
                        <th style={{ textAlign: 'right', width: "10%"  }}>Price</th>
                    </tr>
                </thead>
                <tbody>
                    {product.map(product =>
                        <tr key={product.productId}>
                            {/*<td>{forecast.date}</td>*/}
                            <td>{product.name}</td>
                            <td>{product.description}</td>
                            <td style={{ textAlign: 'right' }}>{product.pricePerUnit}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    static renderPriceButton(rate) {
        return (
            <div> <input type="button" value="AUD" style={{ marginRight: '5px' }}
                onClick={this.updatePrice }
            />{
               
                    rate.map(rate => <input type="button" value={rate.targetCurrency} style={{ marginRight: '5px' }} onClick={this.updatePrice} />)
            }</div>
            );
    }
    

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Catalog.renderProduct(this.state.product);

        //let price = this.state.loading
        //    ? <p><em>Loading...</em></p>
        //    : Catalog.renderPriceButton(this.state.rate);

        return (
            <div>
                <h1>Catalog</h1>
                <p>Here are our product available right now.</p>
                {/*{price}*/}
                {contents}
            </div>
            
            );
    }
}