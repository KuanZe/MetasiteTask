import React, { Component } from 'react';
import axios from 'axios';
import '../styles/homeStyle.css';

export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            startDate: null,
            endDate: null,
            smsCount: null,
            callCount: null,
            smsMsisdns: [],
            callMsisdns: []
        };
    }

    selectNewDate = (newDate, fieldName) => {
        if (fieldName === "startDate")
            this.setState({ startDate: newDate });
        if (fieldName === "endDate")
            this.setState({ endDate: newDate });
    }

    getSmsCount = () => {
        if (this.state.startDate === null || this.state.endDate === null) {
            alert("Please select the dates");
            return;
        }

        axios.get(document.location.origin + '/api/operations/GetSmsCount', {
            params: {
                startDate: this.state.startDate,
                endDate: this.state.endDate
            }
        }).then(res => {
            this.setState({ smsCount: res.data.count });
            }).catch((err) => {
                alert("Something went wrong");
                this.setState({ smsCount: null });
            });
    };

    getCallCount = () => {
        if (this.state.startDate === null || this.state.endDate === null) {
            alert("Please select the dates");
            return;
        }

        axios.get(document.location.origin + '/api/operations/GetCallCount', {
            params: {
                startDate: this.state.startDate,
                endDate: this.state.endDate
            }
        }).then(res => {
            this.setState({ callCount: res.data.count });
        }).catch((err) => {
            alert("Something went wrong");
            this.setState({ callCount: null });
        });
    };

    getTopSmsMsisdns = () => {
        if (this.state.startDate === null || this.state.endDate === null) {
            alert("Please select the dates");
            return;
        }

        axios.get(document.location.origin + '/api/operations/GetTopSmsMsisdns', {
            params: {
                startDate: this.state.startDate,
                endDate: this.state.endDate
            }
        }).then(res => {
            this.setState({ smsMsisdns: res.data.msisdns });
        }).catch((err) => {
            alert("Something went wrong");
            this.setState({ smsMsisdns: [] });
        });
    };

    getTopCallMsisdns = () => {
        if (this.state.startDate === null || this.state.endDate === null) {
            alert("Please select the dates");
            return;
        }

        axios.get(document.location.origin + '/api/operations/GetTopCallMsisdns', {
            params: {
                startDate: this.state.startDate,
                endDate: this.state.endDate
            }
        }).then(res => {
            this.setState({ callMsisdns: res.data.msisdns });
        }).catch((err) => {
            alert("Something went wrong");
            this.setState({ callMsisnds: [] });
        });
    };

    render() {
        return (
            <div className="container">
                <h1>Metasite task</h1>
                <div>
                    Please select the start date: <input type="date" name="dateInput" onChange={(e) => this.selectNewDate(e.target.value, "startDate")} />
                </div>
                <div>
                    Please select the end date: <input type="date" name="dateInput" onChange={(e) => this.selectNewDate(e.target.value, "endDate")} />
                </div>
                <div>               
                    <button type="button" onClick={this.getSmsCount}> Get Sms Count</button>
                    {
                        (this.state.smsCount !== null ?
                            <div>Counted sms: {this.state.smsCount}</div> : null)
                    }
                </div>
                <div>
                    <button type="button" onClick={this.getCallCount}> Get Call Count</button>
                    {
                        (this.state.callCount !== null ?
                            <div>Counted calls: {this.state.callCount}</div> : null)
                    }
                </div>
                <div>
                    <button type="button" onClick={this.getTopSmsMsisdns}> Get Top Sms Msisdns</button>
                    {
                        (this.state.smsMsisdns.length !== 0 ?
                            <table border="1">
                                <tr>
                                    <th>Place</th>
                                    <th>Msisdn</th>
                                </tr>
                                {
                                    this.state.smsMsisdns.map((item, i) => {
                                        return <tr key={i}>
                                            <th>{i+1}</th>
                                            <th>{item}</th>
                                        </tr>;
                                    })
                                }
                            </table>
                            : null)
                    }
                </div>
                <div>
                    <button type="button" onClick={this.getTopCallMsisdns}> Get Top Call Msisdns</button>
                    {
                        (this.state.callMsisdns.length !== 0 ?
                            <table border="1">
                                <tr>
                                    <th>Place</th>
                                    <th>Msisdn</th>
                                </tr>
                                {
                                    this.state.callMsisdns.map((item, i) => {
                                        return <tr key={i}>
                                            <th>{i+1}</th>
                                            <th>{item}</th>
                                        </tr>;
                                    })
                                }
                            </table>
                            : null)
                    }
                </div>
            </div>
        );
    }
}
