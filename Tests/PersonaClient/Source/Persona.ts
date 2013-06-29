module Persona {
	export interface IWatch {
		loggedInUser?: string;
		onlogin: (assertion: string) => void;
		onlogout: () => void;
		onmatch?: () => void;
	}

	export interface IIdentity {
		request();
		logout();
		watch(callbacks: IWatch);
	}

	export interface INavigator {
		id: IIdentity;
	}
}

interface Navigator extends Persona.INavigator {
}