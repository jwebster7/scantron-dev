/* Author: Joe Webster,
           Caleb Schweer,
           William McCreight
 * Date: 12/19/2017
 */
import javafx.application.Application;
import javafx.scene.*;
import javafx.scene.control.*;
import javafx.geometry.*;
import javafx.stage.*;

public class UserInterface extends Application
{
    Stage window;
    
    public static void main(String[] args)
    {
        launch(args);
    }
    
    @Override
    public void start(Stage mainStage) throws Exception
    {
        window = mainStage;
        window.setTitle("Scantron Streamlined");
        window.show();
    }
}
