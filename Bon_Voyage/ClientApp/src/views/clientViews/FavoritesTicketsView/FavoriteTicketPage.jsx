import React, { Component } from "react";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Button } from "primereact/button";

class FavoriteTicket extends Component {
  state = {
    cars: [
      { vin: "20", year: "2020", brand: "Mercedes", color: "color" }
    ]   
  };

  //-------------------------RENDER--------------------------------

  actionTemplate = () => {
    return (
      <div>
        <Button
          type="button"
          icon="pi pi-info"
          className="p-button-info"
          style={{ marginRight: ".5em" }}
        ></Button>
        <Button
          type="button"
          icon="pi pi-shopping-cart"
          className="p-button-success"
        ></Button>
      </div>
    );
  };

  render() {
    let ticketCount = 0;
    let header = (
      <div className="p-clearfix" style={{ lineHeight: "1.87em" }}>
        Список квитків{" "}
        <Button icon="pi pi-refresh" style={{ float: "right" }} />
      </div>
    );
    let footer = "Показано " + ticketCount + " квитків";

    const page = (
      <React.Fragment>
        <div className="mt-3">
          <div className="content-section introduction">
            <div className="feature-intro">
              <h1> </h1>
              <p> </p>
            </div>
          </div>

          <div className="content-section implementation">
            <DataTable value={this.state.cars} header={header} footer={footer}>
              <Column
                field="vin"
                header="Країна"
                style={{ textAlign: "center" }}
              />
              <Column
                field="year"
                header="Місто"
                style={{ textAlign: "center" }}
              />
              <Column
                field="brand"
                header="Готель"
                style={{ textAlign: "center" }}
              />
              <Column
                field="brand"
                header="Дата відльоту"
                style={{ textAlign: "center" }}
              />
              <Column
                field="brand"
                header="Дата прильоту"
                style={{ textAlign: "center" }}
              />
              <Column
                field="brand"
                header="Ціна"
                style={{ textAlign: "center" }}
              />
              <Column
                field="brand"
                header="Кількість місць"
                style={{ textAlign: "center" }}
              />
              <Column
                body={(e) => this.actionTemplate()}
                style={{ textAlign: "center", width: "8em" }}
              />
            </DataTable>
          </div>
        </div>
      </React.Fragment>
    );

    return page;
  }
}

export default FavoriteTicket;
