import java.util.HashMap;
import java.util.HashSet;

class NFA {

    public static class State {
        public final String label;
        private final HashMap<Character,HashSet<State>> transitions
            = new HashMap<Character,HashSet<State>>();
        private boolean accepting = false;
        
        public State(String label) {
            this.label = label;
        }

	public boolean runDepthFirst(String input, int index) {
	    System.out.printf("In state %s\n", label);
	    if (index >= input.length()) {
		System.out.printf("%s\n", accepting ? "ACCEPT" : "REJECT");
		return accepting;
	    }
	    char c = input.charAt(index);
	    System.out.printf("Looking at character %c\n", c);
	    HashSet<State> ts = transitions.get(c);
	    if (ts == null) {
		System.out.println("DIED!");
		return false;
	    }
	    for (State st : ts) {
		boolean ok = st.runDepthFirst(input, index+1);
		if (ok) return true;
	    }
	    System.out.println("BACKTRACK");
	    return false;
	}

        public void setAccepting(boolean value) {
            accepting = value;
        }
        
        public void addTransition(char c, State s) {
            HashSet<State> set = transitions.get(c);
            if (set == null) {
                set = new HashSet<State>();
                transitions.put(c, set);
            }
            set.add(s);
        }

        public void printState() {
            System.out.printf("%s:", label);
            for (Character c : transitions.keySet()) {
                System.out.printf(" <%c ->", c);
                HashSet<State> set = transitions.get(c);
                for (State st : set) {
                    System.out.printf(" %s", st.label);
                }
                System.out.print(">");
            }
            System.out.println();
        }
    }

    
    private final HashSet<State> states = new HashSet<State>();
    private State initialState;

    public void printAutomaton() {
        for (State st : states) {
            st.printState();
        }
    }
    public void setInitialState(State s) { initialState = s; }

    public State makeState(String label) {
        State rv = new State(label);
        states.add(rv);
        return rv;
    }
    
    public static NFA makeSubstringNFA(String prefix, String s) {
        NFA rv = new NFA();
        State s1 = rv.makeState(prefix + "0");
        rv.setInitialState(s1);
        s1.addTransition('a', s1);
        s1.addTransition('b', s1);
        for (int i = 0; i < s.length(); i++) {
            State s2 = rv.makeState(prefix + (i+1));
            s1.addTransition(s.charAt(i), s2);
            s1 = s2;
        }
        s1.addTransition('a', s1);
        s1.addTransition('b', s1);
        s1.setAccepting(true);
        return rv;
    }

    public void runAutomaton(String input) {
	initialState.runDepthFirst(input, 0);
    }
    
    public static void main(String[] args) {
        NFA nfa1 = makeSubstringNFA("a", "abab");
        NFA nfa2 = makeSubstringNFA("a", "babaa");
        nfa1.printAutomaton();
	System.out.println("-----");
        nfa2.printAutomaton();
        for (int i = 0; i < args.length; i++) {
            nfa1.runAutomaton(args[i]);
            nfa2.runAutomaton(args[i]);
        }
    }
    
}
